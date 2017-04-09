(function (angular) {

    angular
        .module("usersModule")
        .controller("UsersController", UsersController);

    UsersController.$inject = ['$scope', "usersService" ];

    function UsersController($scope, usersService) {
        var vm = this;
        vm.users = [];
        //vm.pages = [];
        vm.newUserTitle = "";
        vm.onAddNewUser = onAddNewUser;
        vm.onDeletePressed = onDeletePressed;
        //vm.changePage = changePage;
        vm.isNewUserTitleValid = isNewUserTitleValid;

        activate();

        function activate() {
            var usersPromise = usersService.getUsers();
            usersPromise.then(function (response) {
                console.log("[UsersController] usersPromise - ", response);
                vm.users = [];
                $scope.$applyAsync(function () {
                    vm.users.push.apply(vm.users, response.data);
                });
            });

            //var pagesPromise = usersService.getPages();
            //pagesPromise.then(function (response) {
            //    console.log("[UsersController] getPages - ", response);
            //    vm.pages = [];
            //    $scope.$applyAsync(function () {
            //        vm.pages.push.apply(vm.pages, response.data);
            //    });
            //});

        }

        function onAddNewUser() {
            console.log("[UsersController] onAddNewUser - ", arguments);
            var newUser = { Id: 0, Title: vm.newUserTitle, Done: false };
            usersService
                .addUser(newUser)
                .then(function (response) {
                    console.log("[UsersController] onAddNewUser - success", response);
                    vm.users.push(response.data);
                    vm.newUserTitle = "";
                }, function (response) {
                    console.log("[UsersController] onAddNewUser - fail", response);
                    alert("Adding a new user has failed.");
                });
        }

        function onDeletePressed(user) {
            console.log("[UsersController] onDeletePressed - ", arguments);
            usersService
                .deleteUser(user)
                .then(function (response) {
                    console.log("[UsersController] - success", arguments);
                    vm.users.pop(response.data);
                    vm.users = [];
                    activate();
                }, function () {
                    console.log("[UsersController] - fail", arguments);
                });
        }

        //function changePage(page) {
        //    console.log("[UsersController] onChangePage - ", arguments);
        //    //alert(page);

        //    var usersPromise = usersService.getUsers(page);
        //    usersPromise.then(function (response) {
        //        console.log("[UsersController] usersPromise - ", response);
        //        vm.users = [];
        //        $scope.$applyAsync(function () {
        //            vm.users.push.apply(vm.users, response.data);
        //        });
        //    });
        //}

        function isNewUserTitleValid() {
            return (angular.isString(vm.newUserTitle) && vm.newUserTitle.length >= 1 && vm.newUserTitle.length <= 50);
        }

    }

})(angular);