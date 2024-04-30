import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AsyncPipe, CommonModule } from '@angular/common';
import { CreateRouteComponent } from './components/routes/create-route/create-route.component';
import { HttpClientModule } from '@angular/common/http';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MaterialModule } from './modules/material/material.module';
import { StationsComponent } from './components/routes/create-route/localities/stations/stations.component';
import { LocalitiesComponent } from './components/routes/create-route/localities/localities.component';
import { StationTracksComponent } from './components/routes/create-route/localities/stations/station-tracks/station-tracks.component';
import { CreateStopsComponent } from './components/routes/create-route/create-stops/create-stops.component';
import { StopComponent } from './components/routes/create-route/create-stops/stop/stop.component';

@NgModule({
  declarations: [
    AppComponent,
    CreateRouteComponent,
    StationsComponent,
    LocalitiesComponent,
    StationTracksComponent,
    CreateStopsComponent,
    StopComponent,
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
  ],
  providers: [
    provideAnimationsAsync('noop')
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
