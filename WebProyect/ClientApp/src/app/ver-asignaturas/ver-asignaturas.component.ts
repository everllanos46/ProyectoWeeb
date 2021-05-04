import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Asignatura } from '../models/asignatura';
import { PlanAsignatura } from '../models/plan-asignatura';
import { AsignaturaService } from '../services/asignatura.service';
import { PlanasignaturaService } from '../services/planasignatura.service';
import { AlertModalComponent } from '../@base/alert-modal/alert-modal.component';
@Component({
  selector: 'app-ver-asignaturas',
  templateUrl: './ver-asignaturas.component.html',
  styleUrls: ['./ver-asignaturas.component.css']
})
export class VerAsignaturasComponent implements OnInit {
  asignatura: Asignatura= new Asignatura()
  planAsignatura : PlanAsignatura= new PlanAsignatura();
  form3: boolean = true;
  constructor(private routeActive: ActivatedRoute,private router: Router, private planAsignaturaService : PlanasignaturaService, private asignaturaService: AsignaturaService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.planAsignaturaService.searchAsignatura(this.routeActive.snapshot.params.codigoAsignatura).subscribe(resultado=>{
      if(resultado!=null){
        this.planAsignatura=resultado;    
        this.asignatura=resultado.asignatura
      }
    })
  }

  modify(){
    this.asignaturaService.modify(this.asignatura).subscribe(resultado=>{
      if(resultado!=null){
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Se ha modificado una asignatura';
        console.log(resultado)
      }
    })
  }

  bandera3(){
    this.form3=!this.form3;
  }

  delete(codigo:String){
    this.asignaturaService.delete(codigo).subscribe(resultado=>{
      if(resultado!=null){
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Asignatura Eliminada';
        this.router.navigate(['/asignaturas'])
      }
    }
    )
  }
  

}
