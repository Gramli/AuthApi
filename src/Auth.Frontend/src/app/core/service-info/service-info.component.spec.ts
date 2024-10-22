import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceInfoComponent } from './service-info.component';

describe('ServiceInfoComponent', () => {
  let component: ServiceInfoComponent;
  let fixture: ComponentFixture<ServiceInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ServiceInfoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ServiceInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
