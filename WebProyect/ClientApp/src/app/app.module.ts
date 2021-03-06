
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';
import { MatSliderModule } from '@angular/material/slider';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';
import { AppComponent } from './app.component';

import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { ModalComponent } from './@base/modal/modal.component';
import { VerDocenteComponent } from './ver-docente/ver-docente.component';
import { AlertModalComponent } from './@base/alert-modal/alert-modal.component';
import { VerSolicitudesComponent } from './ver-solicitudes/ver-solicitudes.component';
import { VerSolicitudComponent } from './ver-solicitud/ver-solicitud.component';
import { ModuloPipeModule } from './pipe/modulo-pipe/modulo-pipe.module';



@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ComponentsModule,
    RouterModule,
    AppRoutingModule,
    NgbModule,
    ReactiveFormsModule,
    MatSliderModule,
    ModuloPipeModule,
    BrowserAnimationsModule,
    AccordionModule.forRoot(),
    ToastrModule.forRoot()
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    ModalComponent,
    VerDocenteComponent,
    AlertModalComponent,
    VerSolicitudesComponent,
    VerSolicitudComponent


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
