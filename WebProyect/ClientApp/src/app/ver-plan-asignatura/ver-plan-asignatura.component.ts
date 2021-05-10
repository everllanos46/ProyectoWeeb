import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { PlanAsignatura } from '../models/plan-asignatura';
import { PlanasignaturaService } from '../services/planasignatura.service';

@Component({
  selector: 'app-ver-plan-asignatura',
  templateUrl: './ver-plan-asignatura.component.html',
  styleUrls: ['./ver-plan-asignatura.component.css']
})
export class VerPlanAsignaturaComponent implements OnInit {

  planAsignatura : PlanAsignatura= new PlanAsignatura();
  plan : PlanAsignatura;
  constructor(private router: Router, private routeActive: ActivatedRoute, private planAsignaturaService : PlanasignaturaService) { 
    
  }
  ID=''
  abrir(){
    this.router.navigateByUrl('/solicitud/'+this.ID);
  }
  ngOnInit(): void {
    const id=this.routeActive.snapshot.params.codigoAsignatura;
    debugger
    this.ID=id
    console.log(this.ID)
    this.planAsignaturaService.searchAsignatura(this.ID).subscribe(resultado=>{
      if(resultado!=null){
        this.planAsignatura=resultado;   
        
      }
    })
    
    
  }
  

}
