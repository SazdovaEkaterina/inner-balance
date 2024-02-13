import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YogaClassesComponent } from './yoga-classes.component';

describe('YogaClassesComponent', () => {
  let component: YogaClassesComponent;
  let fixture: ComponentFixture<YogaClassesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [YogaClassesComponent]
    });
    fixture = TestBed.createComponent(YogaClassesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
