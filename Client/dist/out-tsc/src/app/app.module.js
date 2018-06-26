"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_1 = require("@angular/platform-browser");
var animations_1 = require("@angular/platform-browser/animations");
var core_1 = require("@angular/core");
var http_1 = require("@angular/common/http");
var app_component_1 = require("./app.component");
var material_1 = require("@angular/material");
var header_component_1 = require("./Job-application.Feature/components/header/header.component");
var questions_service_1 = require("./Job-application.Feature/services/questions.service");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            declarations: [app_component_1.AppComponent, header_component_1.HeaderComponent],
            imports: [
                platform_browser_1.BrowserModule,
                http_1.HttpClientModule,
                animations_1.BrowserAnimationsModule,
                material_1.MatButtonModule,
                material_1.MatCheckboxModule,
                material_1.MatFormFieldModule,
                material_1.MatSelectModule,
                material_1.MatTabsModule,
                material_1.MatCardModule,
                material_1.MatInputModule
            ],
            providers: [questions_service_1.QuestionsService],
            bootstrap: [app_component_1.AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map