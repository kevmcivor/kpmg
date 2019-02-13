import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsLatestComponent } from './news-latest.component';

describe('NewsLatestComponent', () => {
  let component: NewsLatestComponent;
  let fixture: ComponentFixture<NewsLatestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewsLatestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewsLatestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
