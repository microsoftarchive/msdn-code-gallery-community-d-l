import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';


import { ScrollingModule } from '@angular/cdk/scrolling';

import { DragDropModule } from '@angular/cdk/drag-drop'; 

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ScrollingModule,
    DragDropModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
