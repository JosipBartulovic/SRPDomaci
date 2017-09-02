function addStudentControllerFunction($scope, localStorageService){

	$scope.size = localStorageService.get("Students").length;
	get_all_students($scope, localStorageService);
	
	$scope.submit_clicked = function(){
		add_student_to_local_storage(localStorageService ,new student($scope.Name, $scope.LastName, $scope.sex, $scope.Grade));
		$scope.size = localStorageService.get("Students").length;
		console.log($scope.is_all_input_disabled());
		get_all_students($scope, localStorageService);
	}

	$scope.is_button_disabled = function(){
		if(!$scope.Name || !$scope.LastName || !$scope.sex || !$scope.Grade){
			return true;
		}
		return false;
	}

	$scope.is_all_input_disabled = function(){
		return $scope.size >= 10;
	}
}
