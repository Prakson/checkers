import {Component, Input, OnInit} from '@angular/core';
import {AiStatusClient} from "./ai-status-client.service";
import {Color, Type} from "../shared/dto/piece.interface";
import {Kind} from "./kind";
import {AiPlayerStatus} from "./ai-player-status.interface";
import {DatePipe, NgClass} from "@angular/common";

@Component({
  selector: 'app-ai-agent[boardId]',
  standalone: true,
  imports: [
    DatePipe,
    NgClass
  ],
  providers: [
    {provide: AiStatusClient }
  ],
  templateUrl: './ai-agent.component.html',
  styleUrl: './ai-agent.component.scss'
})
export class AiAgentComponent implements OnInit {
  @Input() boardId!: string;

  // It will be slow as hell but let's optimize it later
  public entries: AiPlayerStatus[] = [];

  constructor(private readonly clientService: AiStatusClient) {
    this.clientService.statusUpdateRequested$.subscribe(x => {
      for(let entry of x) {
        this.entries.unshift(entry);
      }
    })
  }

  ngOnInit(): void {
    console.log(this.boardId)
    this.clientService.initialize(this.boardId);
  }

  public badgeClass(kind: Kind): string {
    switch(kind) {
      case Kind.Command:
        return 'badge bg-primary';
      case Kind.ResultFailed:
        return 'badge bg-danger';
      case Kind.ResultSuccessful:
        return 'badge bg-success';
      default:
        return 'badge badge-secondary';
    }
  }

  protected readonly Type = Type;
  protected readonly Color = Color;
  protected readonly Kind = Kind;
}