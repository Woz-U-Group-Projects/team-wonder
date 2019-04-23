import { Component, OnInit } from '@angular/core';

import { Hair } from '../hair';
import { HairService } from '../hair.service';

@Component({
  selector: 'app-hairs',
  templateUrl: './hairs.component.html',
  styleUrls: ['./hairs.component.css']
})
export class HairsComponent implements OnInit {
    hairs: Hair[];
  constructor(private hairService: HairService) { }

  ngOnInit() {
    this.getHairs();  }

    getHairs(): void {
        this.hairService.getHairs()
        .subscribe(hairs => this.hairs = hairs);
      } 
    
      add(name: string): void {
        name = name.trim();
        if (!name) { return; }
        this.hairService.addHair({ name } as Hair)
          .subscribe(hair => {
            this.hairs.push(hair);
          });
      } 
    
      delete(hair: Hair): void {
        this.hairs = this.hairs.filter(h => h !== hair);
        this.hairService.deleteHair(hair).subscribe();
      }
    
    } 