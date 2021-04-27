import { Routes } from '@angular/router';

import { DashboardComponent } from '../../dashboard/dashboard.component';
import { UserProfileComponent } from '../../user-profile/user-profile.component';
import { TableListComponent } from '../../table-list/table-list.component';
import { TypographyComponent } from '../../typography/typography.component';
import { IconsComponent } from '../../icons/icons.component';
import { MapsComponent } from '../../maps/maps.component';
import { NotificationsComponent } from '../../notifications/notifications.component';
import { UpgradeComponent } from '../../upgrade/upgrade.component';
import {DocentesComponent} from '../../docentes/docentes.component';
import {AsignaturasComponent} from '../../asignaturas/asignaturas.component';
import {VerAsignaturasComponent} from '../../ver-asignaturas/ver-asignaturas.component';
import {VerPlanAsignaturaComponent} from '../../ver-plan-asignatura/ver-plan-asignatura.component';
import {SolicitudComponent} from '../../solicitud/solicitud.component';
import {RegistrarDocenteComponent} from '../../registrar-docente/registrar-docente.component';
import {RegistroAsignaturaComponent} from '../../registro-asignatura/registro-asignatura.component';
import {VerDocenteComponent} from '../../ver-docente/ver-docente.component';
import {VerSolicitudesComponent} from '../../ver-solicitudes/ver-solicitudes.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'user-profile',   component: UserProfileComponent },
    { path: 'table-list',     component: TableListComponent },
    { path: 'typography',     component: TypographyComponent },
    { path: 'icons',          component: IconsComponent },
    { path: 'maps',           component: MapsComponent },
    { path: 'notifications',  component: NotificationsComponent },
    { path: 'upgrade',        component: UpgradeComponent },
    {path: 'docentes',        component: DocentesComponent},
    {path: 'asignaturas',     component: AsignaturasComponent},
    {path: 'verAsignaturas/:codigoAsignatura',     component: VerAsignaturasComponent},
    {path: 'verPlanAsignatura/:codigoAsignatura',     component: VerPlanAsignaturaComponent},
    {path: 'solicitud/:codigoPlan',     component: SolicitudComponent},
    {path: 'registrar',     component: RegistrarDocenteComponent},
    {path: 'registrarAsignatura', component:  RegistroAsignaturaComponent},
    {path: 'verDocente/:id', component:  VerDocenteComponent},
    {path: 'verSolicitud', component:  VerSolicitudesComponent},
];
