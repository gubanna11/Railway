import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserforRegistrationDto } from '../models/user/registration/userForRegistrationDto';
import { RegistrationResponseDto } from '../models/user/registration/registrationResponseDto';
import { UserForAuthDto } from '../models/user/auth/userForAuthDto';
import { AuthResponseDto } from '../models/user/auth/authResponseDto';
import { Subject } from 'rxjs';
import { UserStoreService } from './user-store.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly url = 'Auth';
  private readonly fullRoute = `${environment.apiUrl}/${this.url}`;
  private userPayload: any;

  private authChangeSub = new Subject<boolean>();
  public authChanged = this.authChangeSub.asObservable();

  constructor(private http: HttpClient,
    private jwtHelperService: JwtHelperService,
    private userStoreService: UserStoreService,
  ) {
      this.userPayload = this.decodedToken();
  }

  public register(registerUser: UserforRegistrationDto){
    return this.http.post<RegistrationResponseDto>(`${this.fullRoute}/register`, registerUser);
  }

  public login(userForAuthentication: UserForAuthDto){
    return this.http.post<AuthResponseDto>(`${this.fullRoute}/login`, userForAuthentication)
  }

  public logout(){
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false);
  }

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this.authChangeSub.next(isAuthenticated);
    this.userPayload = this.decodedToken();
    this.userStoreService.setIdForStore(this.getIdFromToken());
    this.userStoreService.setRoleForStore(this.getRoleFromToken());
  }

  public isAuthenticated = (): boolean => {
    const token = localStorage.getItem("token");
    return !!token && !this.jwtHelperService.isTokenExpired(token);
  }

  public isTokenExpired(){
    const token = localStorage.getItem("token");
    return this.jwtHelperService.isTokenExpired(token);
  }

  decodedToken(){
    const token = this.getToken()!;
    return this.jwtHelperService.decodeToken(token);
  }

  getToken(){
    return localStorage.getItem('token');
  }

  public getRoleFromToken(){
    if (this.userPayload){
      return this.userPayload.role;
    }
  }

  public getIdFromToken(){
    if (this.userPayload){
      return this.userPayload.nameid;
    }
  }

  public getP(){
    return this.userPayload;
  }
}
