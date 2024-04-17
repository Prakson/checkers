import {Component, Input, OnInit} from '@angular/core';
import {LobbyClientService} from "./lobby-client-service";
import {CommonModule} from "@angular/common";
import {Router} from "@angular/router";
import {Lobby, LobbyStatus} from "../../shared/dto/lobby.interface";

@Component({
  selector: 'app-lobby',
  standalone: true,
  imports: [CommonModule],
  providers: [
    LobbyClientService
  ],
  templateUrl: './lobby.component.html',
  styleUrl: './lobby.component.scss'
})
export class LobbyComponent implements OnInit {
  @Input() lobbyId!: string;

  public lobby: Lobby|null = null;

  constructor(private readonly client: LobbyClientService, private readonly router: Router) {}

  ngOnInit(): void {
    this.client.initialize(this.lobbyId);
    this.client.lobbyUpdatedRequested$.subscribe(x => {
      console.log(x);
      if (x.status === LobbyStatus.Closed && x.boardId !== null) {
        this.router.navigate(['board/' + x.boardId])
      } else {
        this.lobby = x;
      }
    })
  }

  closeClose() {
    this.client.close().then(x => {
      console.log(x);
    });
  }

  protected readonly LobbyStatus = LobbyStatus;
}