"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var questions_service_1 = require("./questions.service");
describe('QuestionsService', function () {
    beforeEach(function () {
        testing_1.TestBed.configureTestingModule({
            providers: [questions_service_1.QuestionsService]
        });
    });
    it('should be created', testing_1.inject([questions_service_1.QuestionsService], function (service) {
        expect(service).toBeTruthy();
    }));
});
//# sourceMappingURL=questions.service.spec.js.map