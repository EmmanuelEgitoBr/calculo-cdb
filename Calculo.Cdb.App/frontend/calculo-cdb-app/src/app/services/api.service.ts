import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'https://localhost:44332/api/calculations';

  constructor(private http: HttpClient) {}

  enviarDados(dados: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, dados);
  }
}
