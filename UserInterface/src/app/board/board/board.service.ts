﻿import {computed, inject, Injectable, signal} from "@angular/core";
import {Observable, Subject} from "rxjs";
import {BoardClientService} from "../services/board-client.service";
import {HttpErrorResponse} from "@angular/common/http";
import {Square} from "../../shared/dto/square.interface";
import {PossibleMove} from "../../shared/dto/possiblemove.interface";
import {Board} from "../../shared/dto/board.interface";
import {Move} from "../../shared/dto/move.interface";
import {PlayerIdProvider} from "../../shared/authorization/playerid-provider.service";
import {Color} from "../../shared/dto/piece.interface";
import {BoardData} from "../dto/board-data.interface";
import {BoardError} from "./board.error.interface";

@Injectable()
export class BoardService {
  private readonly clientService = inject(BoardClientService);
  private readonly idProvider = inject(PlayerIdProvider);

  readonly selectedSquare = signal<Square|null>(null)
  readonly possibleMoves = signal<PossibleMove[]>([]);
  readonly board = computed<BoardData>(() => this.toBoardData(this.clientService.board()!));
  readonly error = signal<BoardError>({message: '', timestamp: 0});

  public initialize(boardId: string): void {
    this.clientService.initialize(boardId);
  }

  private toBoardData(board: Board): BoardData {
    const playerColor = this.extractPlayerColor(board);
    return {board: board, playerColor: playerColor ?? Color.White};
  }

  private extractPlayerColor(board: Board): Color|null {
    const playerId = this.idProvider.get();
    const participant = board.participants.find(x => x.id === playerId);

    if (participant === undefined) {
      return Color.White;
    }

    return participant.color;
  }

  public select(square: Square) {
    if (square.piece !== null) {
      this.clientService.possibleMoves(square.position).subscribe({
        next: x => {
          if (x.isSuccessful) {
            this.selectedSquare.set(square);
            this.possibleMoves.set(x.value)
          } else {
            this.selectedSquare.set(null);
            this.possibleMoves.set([]);
            this.error.set({message: x.errorMessage, timestamp: Date.now()});
          }
        },
        error: err => this.error.set({message: this.extractError(err), timestamp: Date.now()})
    });
    }

    if (this.selectedSquare() !== null && square.piece === null) {
      const selectedSquare: Square = this.selectedSquare()!;
      const move: Move = {from: selectedSquare.position, to: square.position};
      this.clientService.move(move).subscribe({
        next: x => {
          if (x.isSuccessful) {
            this.selectedSquare.set(null);
            this.possibleMoves.set([]);
          } else {
            this.selectedSquare.set(null);
            this.possibleMoves.set([]);
            this.error.set({message: x.errorMessage, timestamp: Date.now()});
          }
        },
        error: err => this.error.set({message: this.extractError(err), timestamp: Date.now()})
      });
    }
  }

  //TODO: Temporary solution, handle errors properly later
  private extractError(err: HttpErrorResponse): string {
    if (err?.error?.message) {
      return err.error.message;
    }

    return 'Unknown error!';
  }
}
