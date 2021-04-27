import { Component, OnInit } from '@angular/core';
import { Asignatura } from '../models/asignatura';
import { PlanAsignatura } from '../models/plan-asignatura';
import { AsignaturaService } from '../services/asignatura.service';
import { PlanasignaturaService } from '../services/planasignatura.service';

@Component({
  selector: 'app-asignaturas',
  templateUrl: './asignaturas.component.html',
  styleUrls: ['./asignaturas.component.css']
})
export class AsignaturasComponent implements OnInit {

  asignaturas:Asignatura[]=[]
  planAsignaturas: PlanAsignatura[]=[]
  constructor(private asignaturaService: AsignaturaService, private planAsignaturaService: PlanasignaturaService) { }

  ngOnInit(): void {
    this.get();
  }

  get(){
    this.asignaturaService.get().subscribe(resultado=>{
      if(resultado!=null){
        this.asignaturas=resultado;
      }
      console.log(resultado);
    })
  }

  

}
