(function (angular) {

    angular
        .module("usersModule")
        .factory("usersService", usersService);

    usersService.$inject = [ "$http" ];

    function usersService($http) {

        var service = {
            getUsers: getUsersAjax,
            //getPages: getPages,
            addUser: addUser,
            deleteUser: deleteUser
        };

        return service;

        function getUsersAjax() {
            var promise = $http.get("/User/GetUsers");
            return promise;
        }

        //function getUsers() {
        //    if (localStorage.users) {
        //        return JSON.parse(localStorage.users);
        //    } else {
        //        return [];
        //    }
        //}

        //function getPages() {
        //    var promise = $http.get("/User/GetPages");
        //    //alert(localStorage.users);
        //    return promise;
        //}

        function addUser(user) {
            var promise = $http.post("/User/AddUser", user);
            return promise;
        }

        function deleteUser(user) {
            var promise = $http.post("/User/DeleteUser", user);
            return promise;
        }

    }

})(angular);