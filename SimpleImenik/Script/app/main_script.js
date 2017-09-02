var app = angular.module('EUcenik',['LocalStorageModule']);

app.run(function(localStorageService){
	if(!localStorageService.get('Students')){
		localStorageService.set('Students', []);
	}
});


app.controller('StudentCreateController', function($scope, localStorageService){
	$scope.size = localStorageService.get("Students").length;
	get_all_students($scope, localStorageService);
	$scope.submit_clicked = function(){
		add_student_to_local_storage(localStorageService ,new student($scope.Name, $scope.LastName, $scope.sex));
		$scope.size = localStorageService.get("Students").length;
		console.log($scope.is_all_input_disabled());
		get_all_students($scope, localStorageService);
	}

	$scope.is_button_disabled = function(){
		if(!$scope.Name || !$scope.LastName || !$scope.sex){
			return true;
		}
		return false;
	}

	$scope.is_all_input_disabled = function(){
		return $scope.size >= 10;
	}

	$scope.filter = function(){
		var students = get_all_students($scope, localStorageService);
		if($scope.hideM === true){
			students = _.filter(students, function(obj){ return obj.Sex != 'M'});	
		}
		if($scope.hideF === true){
			students = _.filter(students, function(obj){ return obj.Sex != 'F'});	
		}
		if($scope.hideM === false && $scope.hideF === false){
			get_all_students($scope, localStorageService);
			return true;
		}
		$scope.students = students;
	}
});
