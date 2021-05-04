import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Solicitud } from '../models/solicitud';
import { SolicitudService } from '../services/solicitud.service';
import { AlertModalComponent } from '../@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-ver-solicitud',
  templateUrl: './ver-solicitud.component.html',
  styleUrls: ['./ver-solicitud.component.css']
})
export class VerSolicitudComponent implements OnInit {

  solicitud: Solicitud= new Solicitud();
  constructor(private solicitudService: SolicitudService,private routeActive: ActivatedRoute, private modalService: NgbModal) { }

  ngOnInit(): void {
    const id=this.routeActive.snapshot.params.idSolicitud;
    this.solicitudService.search(id).subscribe(resultado=>{
      if(resultado!=null){
        this.solicitud=resultado;    
      }
    })
  }

  modify(){
    this.solicitudService.modify(this.solicitud).subscribe(resultado=>{
      if(resultado!=null){
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Solicitud Revisada';
        console.log(resultado)
      }
    })
  }

}
