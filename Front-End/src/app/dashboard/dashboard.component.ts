import { Component, OnInit } from '@angular/core';
import { Hair } from '../hair';
import { HairService } from '../hair.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: [ './dashboard.component.css' ]
})
export class DashboardComponent implements OnInit {
  hairs: Hair[] = [];

  constructor(private hairService: HairService) { }

  ngOnInit() {
    this.getHairs();
  }

  getHairs(): void {
    this.hairService.getHairs()
      .subscribe(hairs => this.hairs = hairs.slice(1, 5));
  }
}
