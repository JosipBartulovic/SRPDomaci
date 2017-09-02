function listAllControllerFunction($scope, localStorageService){
	get_all_students($scope, localStorageService);
	
	$scope.remove = function(name, lastName){
		delete_student(name, lastName, $scope, localStorageService);
		get_all_students($scope, localStorageService);
	}
}
