/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LibaryComponent } from './libary.component';

describe('LibaryComponent', () => {
  let component: LibaryComponent;
  let fixture: ComponentFixture<LibaryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LibaryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LibaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
