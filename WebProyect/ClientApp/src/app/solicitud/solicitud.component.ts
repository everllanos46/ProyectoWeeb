import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { PlanAsignatura } from '../models/plan-asignatura';
import { PlanasignaturaService } from '../services/planasignatura.service';



@Component({
  selector: 'app-solicitud',
  templateUrl: './solicitud.component.html',
  styleUrls: ['./solicitud.component.css']
})
export class SolicitudComponent implements OnInit {
  form1: boolean = true;
  form2: boolean = true;
  form3: boolean = true;
  form4: boolean=true;
  planAsignatura : PlanAsignatura = new PlanAsignatura();
  plan: PlanAsignatura = new PlanAsignatura();
  
  constructor(private routeActive: ActivatedRoute, private planAsignaturaService:PlanasignaturaService, private router: Router) { }

  ngOnInit(){
    const id=this.routeActive.snapshot.params.codigoPlan;
    console.log(id)
    this.planAsignaturaService.search(id).subscribe(resultado=>{
      if(resultado!=null){
        console.log(resultado)
        this.planAsignatura=resultado;
        this.plan=this.planAsignatura
      }
    })
    console.log(this.plan)
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
