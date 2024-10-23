import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersInfoComponent } from './users-info.component';

describe('UsersInfoComponent', () => {
  let component: UsersInfoComponent;
  let fixture: ComponentFixture<UsersInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UsersInfoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UsersInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
