import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from "./app.component";
import { MatButtonModule, MatCheckboxModule, MatFormFieldModule, MatSelectModule, MatTabsModule, MatCardModule, MatInputModule } from "@angular/material";
import { HeaderComponent } from './Job-application.Feature/components/header/header.component';
import { QuestionsService } from './Job-application.Feature/services/questions.service';

@NgModule({
  declarations: [AppComponent, HeaderComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatSelectModule,
    MatTabsModule,
    MatCardModule,
    MatInputModule
  ],
  providers: [QuestionsService],
  bootstrap: [AppComponent]
})
export class AppModule {}
