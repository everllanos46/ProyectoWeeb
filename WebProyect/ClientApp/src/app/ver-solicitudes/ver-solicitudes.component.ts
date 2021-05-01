import { Component, OnInit } from '@angular/core';
import { Solicitud } from '../models/solicitud';
import { SolicitudService } from '../services/solicitud.service';

@Component({
  selector: 'app-ver-solicitudes',
  templateUrl: './ver-solicitudes.component.html',
  styleUrls: ['./ver-solicitudes.component.css']
})
export class VerSolicitudesComponent implements OnInit {
 
  solicitudes : Solicitud[]=[]
  constructor(private solicitudService: SolicitudService) { }
 
  ngOnInit(): void {
    this.get()
  }

  get(){
    this.solicitudService.get().subscribe(resultado=>{
      if(resultado!=null){
        this.solicitudes=resultado;
      }
      console.log(resultado);
    })
  }

}
