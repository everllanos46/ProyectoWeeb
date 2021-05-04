import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FiltroSolicitudPipe} from '../filtro-solicitud.pipe';


@NgModule({
  declarations: [FiltroSolicitudPipe],
  exports:[FiltroSolicitudPipe],
  imports: [
    CommonModule
  ]
})
export class ModuloPipeModule { }
