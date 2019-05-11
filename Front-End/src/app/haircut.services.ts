import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { HairCut } from './hairCut';
import { MessageService } from './message.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class HairCutService {

  private hairCutsUrl = 'https://localhost:5001/api/HairCut';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  
  getHairs (): Observable<HairCut[]> {
    return this.http.get<HairCut[]>(this.hairCutsUrl)
      .pipe(
        tap(hairCut => this.log('fetched hairCut')),
        catchError(this.handleError('getHairCut', []))
      );
  }

  
  getHairCutNo404<Data>(id: number): Observable<HairCut> {
    const url = `${this.hairCutsUrl}/?id=${id}`;
    return this.http.get<HairCut[]>(url)
      .pipe(
        map(hairCut => hairCut[0]), 
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} hairCut id=${id}`);
        }),
        catchError(this.handleError<HairCut>(`getHairCut id=${id}`))
      );
  }

  
  getHairCut(id: number): Observable<HairCut> {
    const url = `${this.hairCutsUrl}/${id}`;
    return this.http.get<HairCut>(url).pipe(
      tap(_ => this.log(`fetched hairCut id=${id}`)),
      catchError(this.handleError<HairCut>(`getHairCut id=${id}`))
    );
  }

  
  searchHairCut(term: string): Observable<HairCut[]> {
    if (!term.trim()) {
      
      return of([]);
    }
    return this.http.get<HairCut[]>(`${this.hairCutsUrl}/?name=${term}`).pipe(
      tap(_ => this.log(`found hairCut matching "${term}"`)),
      catchError(this.handleError<HairCut[]>('searchHairCut', []))
    );
  }

  
  addHairCut (hairCut: HairCut): Observable<HairCut> {
    return this.http.post<HairCut>(this.hairCutsUrl, hairCut, httpOptions).pipe(
      tap((hairCut: HairCut) => this.log(`added hairCut w/ id=${hairCut.id}`)),
      catchError(this.handleError<HairCut>('addHairCut'))
    );
  }

  
  deleteHairCutr (hairCut: HairCut | number): Observable<HairCut> {
    const id = typeof hairCut === 'number' ? hairCut : hairCut.id;
    const url = `${this.hairCutsUrl}/${id}`;

    return this.http.delete<HairCut>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted hairCut id=${id}`)),
      catchError(this.handleError<HairCut>('deleteHairCut'))
    );
  }

  
  updateHairCut (hairCut: HairCut): Observable<any> {
    return this.http.put(this.hairCutsUrl, hairCut, httpOptions).pipe(
      tap(_ => this.log(`updated hairCut id=${hairCut.id}`)),
      catchError(this.handleError<any>('updateHairCut'))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      
      console.error(error); 

      
      this.log(`${operation} failed: ${error.message}`);

      
      return of(result as T);
    };
  }

  
  private log(message: string) {
    this.messageService.add(`HairCutService: ${message}`);
  }
}
