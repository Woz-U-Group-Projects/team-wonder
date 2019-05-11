import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { updo } from './updo';
import { MessageService } from './message.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class updoService {

  private updosUrl = 'https://localhost:5001/api/updo';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  
  getHairs (): Observable<updo[]> {
    return this.http.get<updo[]>(this.updosUrl)
      .pipe(
        tap(updo => this.log('fetched updo')),
        catchError(this.handleError('getupdo', []))
      );
  }

  
  getHairCutNo404<Data>(id: number): Observable<updo> {
    const url = `${this.updosUrl}/?id=${id}`;
    return this.http.get<updo[]>(url)
      .pipe(
        map(updo => updo[0]), 
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} updo id=${id}`);
        }),
        catchError(this.handleError<updo>(`getupdo id=${id}`))
      );
  }

  
  getupdo(id: number): Observable<updo> {
    const url = `${this.updosUrl}/${id}`;
    return this.http.get<updo>(url).pipe(
      tap(_ => this.log(`fetched updo id=${id}`)),
      catchError(this.handleError<updo>(`getupdo id=${id}`))
    );
  }

  
  searchHairCut(term: string): Observable<updo[]> {
    if (!term.trim()) {
      
      return of([]);
    }
    return this.http.get<updo[]>(`${this.updosUrl}/?name=${term}`).pipe(
      tap(_ => this.log(`found updo matching "${term}"`)),
      catchError(this.handleError<updo[]>('searchupdo', []))
    );
  }

  
  addupdo (updo: updo): Observable<updo> {
    return this.http.post<updo>(this.updosUrl, updo, httpOptions).pipe(
      tap((upDo: updo) => this.log(`added upDo w/ id=${upDo.id}`)),
      catchError(this.handleError<updo>('addupdo'))
    );
  }

  
  deleteupdo (upDo: updo | number): Observable<updo> {
    const id = typeof upDo === 'number' ? upDo : upDo.id;
    const url = `${this.updosUrl}/${id}`;

    return this.http.delete<updo>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted upDo id=${id}`)),
      catchError(this.handleError<updo>('deleteupdo'))
    );
  }

  
  updateupdo (upDo: updo): Observable<any> {
    return this.http.put(this.updosUrl, upDo, httpOptions).pipe(
      tap(_ => this.log(`updated upDo id=${upDo.id}`)),
      catchError(this.handleError<any>('updatupdo'))
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
    this.messageService.add(`updoService: ${message}`);
  }
}
