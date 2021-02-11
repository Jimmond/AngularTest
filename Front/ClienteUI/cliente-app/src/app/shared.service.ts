import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl = "http://localhost:5000/api/cliente";
  constructor(private http:HttpClient) { }

  getClienteList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl);
  }
  addCliente(val:any){
    return this.http.post<any>(this.APIUrl,val);
  }
  updateCliente(val:any){
    return this.http.put<any>(this.APIUrl,val);
  }
  deleteCliente(val:any){
    return this.http.delete<any>(this.APIUrl,val);
  }
}
