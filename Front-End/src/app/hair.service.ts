import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Hair } from './hair';
import { MessageService } from './message.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class HairService {

  private hairsUrl = 'https://localhost:5001/api/HairColor';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  
  getHairs (): Observable<Hair[]> {
    return this.http.get<Hair[]>(this.hairsUrl)
      .pipe(
        tap(hairs => this.log('fetched hairs')),
        catchError(this.handleError('getHairs', []))
      );
  }

  
  getHairNo404<Data>(id: number): Observable<Hair> {
    const url = `${this.hairsUrl}/?id=${id}`;
    return this.http.get<Hair[]>(url)
      .pipe(
        map(hairs => hairs[0]), 
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} hair id=${id}`);
        }),
        catchError(this.handleError<Hair>(`getHair id=${id}`))
      );
  }

  
  getHair(id: number): Observable<Hair> {
    const url = `${this.hairsUrl}/${id}`;
    return this.http.get<Hair>(url).pipe(
      tap(_ => this.log(`fetched hair id=${id}`)),
      catchError(this.handleError<Hair>(`getHair id=${id}`))
    );
  }

  
  searchHairs(term: string): Observable<Hair[]> {
    if (!term.trim()) {
      
      return of([]);
    }
    return this.http.get<Hair[]>(`${this.hairsUrl}/?name=${term}`).pipe(
      tap(_ => this.log(`found hairs matching "${term}"`)),
      catchError(this.handleError<Hair[]>('searchHairs', []))
    );
  }

  
  addHair (hair: Hair): Observable<Hair> {
    return this.http.post<Hair>(this.hairsUrl, hair, httpOptions).pipe(
      tap((hair: Hair) => this.log(`added hair w/ id=${hair.id}`)),
      catchError(this.handleError<Hair>('addHair'))
    );
  }

  
  deleteHair (hair: Hair | number): Observable<Hair> {
    const id = typeof hair === 'number' ? hair : hair.id;
    const url = `${this.hairsUrl}/${id}`;

    return this.http.delete<Hair>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted hair id=${id}`)),
      catchError(this.handleError<Hair>('deleteHair'))
    );
  }

  
  updateHair (hair: Hair): Observable<any> {
    return this.http.put(this.hairsUrl, hair, httpOptions).pipe(
      tap(_ => this.log(`updated hair id=${hair.id}`)),
      catchError(this.handleError<any>('updateHair'))
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
    this.messageService.add(`HairService: ${message}`);
  }
}
