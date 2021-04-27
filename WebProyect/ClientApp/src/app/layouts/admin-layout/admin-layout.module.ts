import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminLayoutRoutes } from './admin-layout.routing';
import { DashboardComponent } from '../../dashboard/dashboard.component';
import { UserProfileComponent } from '../../user-profile/user-profile.component';
import { TableListComponent } from '../../table-list/table-list.component';
import { TypographyComponent } from '../../typography/typography.component';
import { IconsComponent } from '../../icons/icons.component';
import { MapsComponent } from '../../maps/maps.component';
import { NotificationsComponent } from '../../notifications/notifications.component';
import { ChartsModule } from 'ng2-charts';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';
import { UpgradeComponent } from '../../upgrade/upgrade.component';
import {DocentesComponent} from '../../docentes/docentes.component';
import {AsignaturasComponent} from '../../asignaturas/asignaturas.component';
import {VerAsignaturasComponent} from '../../ver-asignaturas/ver-asignaturas.component';
import {SolicitudComponent} from '../../solicitud/solicitud.component';
import {RegistrarDocenteComponent} from '../../registrar-docente/registrar-docente.component';
import {RegistroAsignaturaComponent} from '../../registro-asignatura/registro-asignatura.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    ChartsModule,
    NgbModule,
    ToastrModule.forRoot()
  ],
  declarations: [
    DashboardComponent,
    UserProfileComponent,
    TableListComponent,
    UpgradeComponent,
    TypographyComponent,
    IconsComponent,
    MapsComponent,
    NotificationsComponent,
    DocentesComponent,
    AsignaturasComponent,
    VerAsignaturasComponent,
    SolicitudComponent,
    RegistrarDocenteComponent,
    RegistroAsignaturaComponent

  ]
})

export class AdminLayoutModule {}
