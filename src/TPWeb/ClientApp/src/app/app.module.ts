import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { LstDevComponent } from './developer/lst-dev/lst-dev.component';
import { FrmDevComponent } from './developer/frm-dev/frm-dev.component';
import { CheckboxGroupComponent } from './shared/checkbox-group/checkbox-group.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LstDevComponent,
    FrmDevComponent,
    CheckboxGroupComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LstDevComponent, pathMatch: 'full' },
      { path: 'frm-dev', component: FrmDevComponent },
    ]),
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
