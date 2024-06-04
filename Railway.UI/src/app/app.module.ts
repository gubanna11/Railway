import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AsyncPipe, CommonModule } from '@angular/common';
import { CreateRouteComponent } from './components/routes/create-route/create-route.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MaterialModule } from './modules/material/material.module';
import { StationsComponent } from './components/routes/create-route/localities/stations/stations.component';
import { LocalitiesComponent } from './components/routes/create-route/localities/localities.component';
import { StationTracksComponent } from './components/routes/create-route/localities/stations/station-tracks/station-tracks.component';
import { CreateStopsComponent } from './components/routes/create-route/create-stops/create-stops.component';
import { StopComponent } from './components/routes/create-route/create-stops/stop/stop.component';
import { ScheduleComponent } from './components/routes/create-route/schedule/schedule.component';
import { CreateTicketComponent } from './components/tickets/create-ticket/create-ticket.component';
import { HomeComponent } from './components/home/home.component';
import { MenuComponent } from './components/menu/menu.component';
import { SeatsInfoComponent } from './components/seats/seats-info/seats-info.component';
import { MyTicketsComponent } from './components/tickets/my-tickets/my-tickets.component';
import { AuthModule } from './modules/auth/auth.module';
import { JwtModule } from '@auth0/angular-jwt';
import { ErrorHandlerInterceptor } from './interceptors/token.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    CreateRouteComponent,
    StationsComponent,
    LocalitiesComponent,
    StationTracksComponent,
    CreateStopsComponent,
    StopComponent,
    ScheduleComponent,
    CreateTicketComponent,
    HomeComponent,
    MenuComponent,
    SeatsInfoComponent,
    MyTicketsComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule, 
    MaterialModule,
    ReactiveFormsModule,
    AsyncPipe,
    AuthModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => localStorage.getItem("token"),
        allowedDomains: ["localhost:44359"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [
    provideAnimationsAsync('noop'),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlerInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
