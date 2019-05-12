// import { Component, OnInit } from '@angular/core';

// import { Observable, Subject } from 'rxjs';

// import {
//    debounceTime, distinctUntilChanged, switchMap
//  } from 'rxjs/operators';

// import { Haircut } from '../haircut';
// import { HaircutService } from '../haircut.service';

// @Component({
//   selector: 'app-haircut-search',
//   templateUrl: './haircut-search.component.html',
//   styleUrls: [ './haircut-search.component.css' ]
// })
// export class HaircutSearchComponent implements OnInit {
//   haircuts$: Observable<Haircut[]>;
//   private searchTerms = new Subject<string>();

//   constructor(private haircutService: HaircutService) {}

  
//   search(term: string): void {
//     this.searchTerms.next(term);
//   }

//   ngOnInit(): void {
//     this.haircuts$ = this.searchTerms.pipe(
      
//       debounceTime(300),

      
//       distinctUntilChanged(),

      
//       switchMap((term: string) => this.haircutService.searchHaircuts(term)), 
//     );
    
//     }
// }
