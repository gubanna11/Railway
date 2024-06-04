import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { Roles } from "../../models/static/roles";
import { UserStoreService } from '../../services/user-store.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent implements OnInit {
  public isUserAuthenticated!: boolean;
  Roles = Roles;
  role?: string;

  constructor(public authService: AuthService,
    private router: Router,
    private userStoreService: UserStoreService,
  ) {
  }

  ngOnInit(): void {
    this.isUserAuthenticated = this.authService.isAuthenticated();

    this.userStoreService.getRoleFromStore()
      .subscribe(role => {
        const roleFromToken = this.authService.getRoleFromToken();

        this.role = role || roleFromToken;
      })

    this.authService.authChanged
      .subscribe(res => {

        this.isUserAuthenticated = res;
      });
  }

  public logout = () => {
    this.authService.logout();
    this.router.navigate(["/"]);
  }
}
