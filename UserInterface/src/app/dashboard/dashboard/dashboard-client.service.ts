﻿import {inject, Injectable, signal} from "@angular/core";
import {ApiConfiguration} from "../../app.config";
import {Lobby} from "../../shared/dto/lobby.interface";
import {HubConnectionBuilder, HubConnection} from "@microsoft/signalr";
import {PlayerIdProvider} from "../../shared/authorization/playerid-provider.service";
import {ActionResult} from "../../shared/dto/action-result.interface";

@Injectable()
export class DashboardClientService {
  config = inject(ApiConfiguration);
  playerIdProvider = inject(PlayerIdProvider);

  private readonly hubConnection: HubConnection;

  lobbies = signal<Lobby[]>([]);

  constructor() {
    const playerId = this.playerIdProvider.get();
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.config.baseUrl + 'hub_dashboard?playerId=' + playerId)
      .build();

    this.hubConnection.start()
      .then(() => {console.log("SignalR alive!")})
      .catch(err => console.log('Error while starting SignalR connection: ', err));

    this.hubConnection.on('LobbiesUpdated', (lobbies: Lobby[]) => this.lobbies.set(lobbies));
  }

  public join(lobbyId: string): Promise<ActionResult<Lobby>> {
    return this.hubConnection.invoke<ActionResult<Lobby>>('JoinLobby', lobbyId);
  }

  public createLobby(name: string): Promise<ActionResult<Lobby>> {
    return this.hubConnection.invoke<ActionResult<Lobby>>('CreateLobby', name);
  }
}
