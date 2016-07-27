(function (app) {
    "use strict";

    app.controller("fileUploadCtrl", fileUploadCtrl);

    fileUploadCtrl.$inject = ["$scope", "$http", "$timeout", "$upload"];

    function fileUploadCtrl($scope, $http, $timeout, $upload) {
        $scope.upload = [];
        $scope.UploadedFiles = [];
        $scope.startUploading = startUploading;

        function startUploading($files) {
            //$files: an array of files selected
            for (var i = 0; i < $files.length; i++) {
                var $file = $files[i];
                (function (index) {
                    $scope.upload[index] = $upload.upload({
                        url: "./api/fileupload", // webapi url
                        method: "POST",
                        file: $file
                    }).progress(function (evt) {
                    }).success(function (data, status, headers, config) {
                        // file is uploaded successfully
                        $scope.UploadedFiles.push({ FileName: data.FileName, FilePath: data.LocalFilePath, FileLength: data.FileLength });
                    }).error(function (data, status, headers, config) {
                        console.log(data);
                    });
                })(i);
            }
        }
    }
}(angular.module("angularUploadApp")));