import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Docente } from '../models/docente';
import { DocentesService} from '../services/docentes.service';
@Component({
  selector: 'app-ver-docente',
  templateUrl: './ver-docente.component.html',
  styleUrls: ['./ver-docente.component.css']
})
export class VerDocenteComponent implements OnInit {
  docente: Docente = new Docente();
  constructor(private routeActive: ActivatedRoute, private docenteService:DocentesService, private router: Router) { }

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
        alert("Persona eliminada correctamente")
        this.router.navigate(['/docentes'])
      }
    }
    )
  }

  modify(){
    this.docenteService.modify(this.docente).subscribe(resultado=>{
      if(resultado!=null){
        alert("Docente modificado correctamente");
        console.log(resultado)
      }
    })
  }

}
