import {Component, OnDestroy} from '@angular/core';
import {CommonModule} from "@angular/common";
import {Lobby, LobbyStatus} from "../../shared/dto/lobby.interface";
import {DashboardClientService} from "./dashboard-client.service";
import {Subscription} from "rxjs";
import {Router} from "@angular/router";
import {NgbAlert, NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {DashboardLobbyCreateComponent} from "../dashboard-lobby-create/dashboard-lobby-create.component";
import {ModalResult} from "../../shared/result/modal-result";
import {ToastrModule, ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, ToastrModule, NgbAlert],
  providers: [
    {provide: DashboardClientService}
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent implements OnDestroy {

  public lobbies: Lobby[] = [];
  private readonly lobbiesUpdatedSubscription: Subscription;

  constructor(
    private readonly clientService: DashboardClientService,
    private readonly router: Router,
    private readonly modal: NgbModal,
    private readonly toastr: ToastrService) {
    this.lobbiesUpdatedSubscription = clientService.lobbiesUpdatedRequested$.subscribe(x => this.lobbies = x);
  }

  joinLobby(id: string) {
    this.clientService.join(id).then(x => {
      if (!x.isSuccessful) {
        if (x.errorCode === 'LOBBY_JOIN_FAILED_PLAYER_ALREADY_IN_THE_LOBBY') {
          this.router.navigate(['lobby/' + id]).then();
          return;
        }

        this.toastr.error(x.errorMessage, 'Failed to join lobby');
      } else {
        const lobbyId = x.value.id;
        this.router.navigate(['lobby/' + lobbyId]).then();
      }
    })
  }

  createLobby(): void {
    this.modal.open(DashboardLobbyCreateComponent).result.then((x: ModalResult) => {
      if (!x.isFinalized) {
        return;
      }

      this.clientService.createLobby(x.value).then(x => {
        if (!x.isSuccessful) {
          this.toastr.error(x.errorMessage, 'Failed to create lobby');
          return;
        }

        const lobbyId = x.value.id;
        this.router.navigate(['lobby/' + lobbyId]).then()
      })
    });
  }


  ngOnDestroy(): void {
    this.lobbiesUpdatedSubscription.unsubscribe();
  }

  protected readonly LobbyStatus = LobbyStatus;
}
