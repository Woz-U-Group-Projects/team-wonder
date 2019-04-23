import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Hair }         from '../hair';
import { HairService }  from '../hair.service';

@Component({
  selector: 'app-hair-detail',
  templateUrl: './hair-detail.component.html',
  styleUrls: [ './hair-detail.component.css' ]
})
export class HairDetailComponent implements OnInit {
  @Input() hair: Hair;

  constructor(
    private route: ActivatedRoute,
    private hairService: HairService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getHair();
  }

  getHair(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.hairService.getHair(id)
      .subscribe(hair => this.hair = hair);
  }

  goBack(): void {
    this.location.back();
  }

 save(): void {
    this.hairService.updateHair(this.hair)
      .subscribe(() => this.goBack());
  }
}
