(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("storyResource", ["$resource", storyResource])

    function storyResource($resource) {
        return $resource("/api/story/:id");
    }

}());