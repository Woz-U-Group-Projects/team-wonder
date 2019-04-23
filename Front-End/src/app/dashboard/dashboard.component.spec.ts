import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardComponent } from './dashboard.component';
import { HairSearchComponent } from '../hair-search/hair-search.component';

import { RouterTestingModule } from '@angular/router/testing';
import { of } from 'rxjs';
import { HAIRS } from '../mock-hairs';
import { HairService } from '../hair.service';

describe('DashboardComponent', () => {
  let component: DashboardComponent;
  let fixture: ComponentFixture<DashboardComponent>;
  let hairService;
  let getHairsSpy;

  beforeEach(async(() => {
    hairService = jasmine.createSpyObj('HairService', ['getHairs']);
    getHairsSpy = hairService.getHairs.and.returnValue( of(HAIRS) );
    TestBed.configureTestingModule({
      declarations: [
        DashboardComponent,
        HairSearchComponent
      ],
      imports: [
        RouterTestingModule.withRoutes([])
      ],
      providers: [
        { provide: HairService, useValue: hairService }
      ]
    })
    .compileComponents();

  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });

  it('should display "Top Hairs" as headline', () => {
    expect(fixture.nativeElement.querySelector('h3').textContent).toEqual('Top Hairs');
  });

  it('should call hairService', async(() => {
    expect(getHairsSpy.calls.any()).toBe(true);
    }));

  it('should display 4 links', async(() => {
    expect(fixture.nativeElement.querySelectorAll('a').length).toEqual(4);
  }));

});
