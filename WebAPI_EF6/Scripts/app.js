var ViewModel = function () {
    var self = this;
    self.courses = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();
    self.instructors = ko.observableArray();
    self.newCourse = {
        Instructor: ko.observable(),
        Dept: ko.observable(),
        Price: ko.observable(),
        Title: ko.observable(),
        Credits: ko.observable(),
        StartDate: ko.observable()
    }

    var coursesUri = '/api/courses/';
    var instructorsUri = '/api/instructors/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllCourses() {
        ajaxHelper(coursesUri, 'GET').done(function (data) {
            self.courses(data);
        });
    }

    self.getCourseDetail = function (item) {
        ajaxHelper(coursesUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    function getInstructors() {
        ajaxHelper(instructorsUri, 'GET').done(function (data) {
            self.instructors(data);
        });
    }

    self.addCourse = function (formElement) {
        var course = {
            InstructorId: self.newCourse.Instructor().Id,
            Dept: self.newCourse.Dept(),
            Price: self.newCourse.Price(),
            Title: self.newCourse.Title(),
            Credits: self.newCourse.Credits(),
            StartDate: self.newCourse.StartDate()
        };

        ajaxHelper(coursesUri, 'POST', course).done(function (item) {
            self.courses.push(item);
        });
    }

    // Fetch the initial data.
    getAllCourses();
    getInstructors();
};

ko.applyBindings(new ViewModel());