﻿import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { ContactRoutingModule } from './contact.routing';
import { ContactComponent }  from './contact.component';
import { ContactDisplayComponent } from '../components/contact-display/contact-display.component';
import { ContactFormComponent } from '../components/contact-form/contact-form.component';

@NgModule({
  imports: [ 
    BrowserModule,
    FormsModule,
    ContactRoutingModule
  ],
  declarations: [ 
    ContactComponent,
    ContactDisplayComponent,
    ContactFormComponent 
  ],
  bootstrap:    [ ContactComponent ]
})
export class ContactModule { }