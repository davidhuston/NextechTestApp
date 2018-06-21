(function () {
    "use strict";
    angular
        .module("nextechApp")
        .controller("StoryListController",
        ["storyResource", StoryListController]);

    function StoryListController(storyResource) {
        var vm = this;
        vm.searching = false;
        vm.message = "";

        storyResource.query(function (data) {
            vm.stories = data;
        });

        vm.searchItems = function () {
            //alert("search:" + vm.searchText);
            vm.message = "Please be patient ...";
            vm.searching = true;
            if (vm.searchText && vm.searchText != '') {
                storyResource.query({ search: vm.searchText }, function (data) {
                    vm.stories = data;
                    vm.message = "";
                    vm.searching = false;
                });
            }
            else {
                storyResource.query(function (data) {
                    vm.stories = data;
                    vm.message = "";
                    vm.searching = false;
                });
            }
        }

    }
}());