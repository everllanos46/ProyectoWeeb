import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from '../@base/alert-modal/alert-modal.component';
import { Asignatura } from '../models/asignatura';
import { PlanAsignatura } from '../models/plan-asignatura';
import { PlanasignaturaService } from '../services/planasignatura.service';


@Component({
  selector: 'app-registro-asignatura',
  templateUrl: './registro-asignatura.component.html',
  styleUrls: ['./registro-asignatura.component.css']
})
export class RegistroAsignaturaComponent implements OnInit {
  form1: boolean = true;
  form2: boolean = true;
  form3: boolean = true;
  form4: boolean=true;
  asignatura : Asignatura
  planAsignatura : PlanAsignatura
  constructor(private planasignaturaservice : PlanasignaturaService, private modalService: NgbModal ) { 
  

  }

  ngOnInit(): void {
    this.asignatura= new Asignatura()
    this.planAsignatura= new PlanAsignatura()
  }

  guardarPlan(){
    this.planAsignatura.asignatura=this.asignatura
    this.planasignaturaservice.post(this.planAsignatura).subscribe(resultado=>{
      if(resultado!=null){
        this.planAsignatura=resultado;
        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Info: Se ha agregado un plan de asignatura';
      }
    });
  }


  bandera(){
    this.form1 = !this.form1;
  }
  bandera2(){
    this.form2 = !this.form2;
  }
  bandera3(){
    this.form3=!this.form3;
  }
  bandera4(){
    this.form4=!this.form4;
  }

}
