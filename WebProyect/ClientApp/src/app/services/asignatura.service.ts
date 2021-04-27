import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Docente } from '../models/docente';
import { environment } from '../../environments/environment';
import { Asignatura } from '../models/asignatura';


const ruta = environment.ruta;
@Injectable({
  providedIn: 'root'
})
export class AsignaturaService {

  constructor(private http: HttpClient,
    private handleErrorService: HandleHttpErrorService) { }

    get():Observable<Asignatura[]>{
      return this.http.get<Asignatura[]>(ruta+"api/Asignatura").pipe(
        tap(()=>console.log("Consultado correctamente"))
      )
    }

    modify(asignatura: Asignatura){
      const httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      };
      return this.http.put(ruta+"api/Asignatura"+"/asignatura", asignatura, httpOptions).pipe(
        tap(()=>console.log("Modificado correctamente"))
      )
    }
}
