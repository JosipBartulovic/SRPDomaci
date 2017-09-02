var app = angular.module('E-ucenik', ['ui.router','LocalStorageModule']);

app.config(function($stateProvider){
	$stateProvider
	.state('home',{
		url : '/',
		controller : 'homeController',
		template:	
			`
			<center>
				<h1>Dobrodosli na imenjik</h1>
				<button ui-sref='ListAll'>Pregledaj sve ucenike</button>
			</center>
			`
		})
	
	.state('ListAll',{
		url: '/listAll',
		controller: 'listAllController',
		template: 
			`
			<h1>All Students</h1>
			<div ng-repeat='student in students'>
				{{student.PrintText}}
				<button ui-sref='Details({Name: student.Name, LastName: student.LastName, Details: student.Details, Age: student.Age, Grade: student.Grade})'>View</button>
				<button ng-click='remove(student.Name, student.LastName)'>Delete {{student.Name}}</button>
			</div>
			<br>
			<br>
			<button ui-sref='AddStudent'>Add Student</button>
			`,
		params: {Name: null, LastName: null}
	})
	
	.state('AddStudent',{
		url: '/addStudent',
		controller: 'addStudentController',
		template: 
			`
			<div ng-controller='addStudentController'>
				<input ng-model='Name' ng-disabled='is_all_input_disabled()'> Name</input>
				<br>
				<input ng-model='LastName' ng-disabled='is_all_input_disabled()'> Last Name</input>
				<br>
				<input ng-model='Grade' ng-disabled='is_all_input_disabled()'> Grade</input>
				<br>
				<input class='radio' type='radio' value='M' ng-model='sex' ng-disabled='is_all_input_disabled()'>M</input>
				<input class='radio' type='radio' value='F' ng-model='sex' ng-disabled='is_all_input_disabled()'>F</input>
				<br>
				<br>
				<button ng-click='submit_clicked()' ng-disabled='is_button_disabled() || is_all_input_disabled()'>Submit</button>
				<button ui-sref='ListAll'>List All Students</button>
			</div>
			`
	})

	.state('Details',{
		url: '/details/:Name',
		controller: 'detailsController',
		template:
			`
				<h1>Student details<h1>
				<div>
					{{Details}}
				<div>
				<button ui-sref='ListAll'>List All Students</button>
			`,
		params: {
			Name: student.Name,
			LastName: student.LastName,
			Age: student.Age,
			Grade: student.Grade,
			Details: null	
		}	
	})
	
});


app.controller('homeController',function($scope){});
app.controller('listAllController', listAllControllerFunction);
app.controller('addStudentController', addStudentControllerFunction);
app.controller('detailsController', detailsControllerFunction);
