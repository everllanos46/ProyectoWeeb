import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Docente } from '../models/docente';
import { DocentesService} from '../services/docentes.service';
import { AlertModalComponent } from '../@base/alert-modal/alert-modal.component';
@Component({
  selector: 'app-ver-docente',
  templateUrl: './ver-docente.component.html',
  styleUrls: ['./ver-docente.component.css']
})
export class VerDocenteComponent implements OnInit {
  docente: Docente = new Docente();
  constructor(private routeActive: ActivatedRoute, private docenteService:DocentesService, private router: Router, private modalService: NgbModal ) { }

  ngOnInit(): void {
    const id=this.routeActive.snapshot.params.id;
    this.docenteService.search(id).subscribe(resultado=>{
      if(resultado!=null){
        this.docente=resultado;
      }
      console.log(resultado);
    })
  }

  delete(identificacion:String){
    this.docenteService.delete(identificacion).subscribe(resultado=>{
      if(resultado!=null){
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Se ha eliminado un docente';
        this.router.navigate(['/docentes'])
      }
    }
    )
  }

  modify(){
    this.docenteService.modify(this.docente).subscribe(resultado=>{
      if(resultado!=null){
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Se ha modificado un docente';
        console.log(resultado)
      }
    })
  }

}
