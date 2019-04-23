import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { HairsComponent } from './hairs.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('HairsComponent', () => {
    let component: HairsComponent;
    let fixture: ComponentFixture<HairsComponent>;
  
    beforeEach(async(() => {
      TestBed.configureTestingModule({
        declarations: [ HairsComponent ],
        imports: [RouterTestingModule.withRoutes([]), HttpClientTestingModule],
      })
      .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(HairsComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
      });
    
      it('should be created', () => {
        expect(component).toBeTruthy();
      });
    });