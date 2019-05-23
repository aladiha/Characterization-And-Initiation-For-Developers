pipeline {
    //Use the following docker image to run your dotnet app.
   // agent { docker { image 'mcr.microsoft.com/dotnet/core/sdk:2.2-alpine' } }
   // environment {HOME = '/tmp'} 
    stages {
       
    // Get some code from a GitHub repository
    stage('Git') {
      steps{
          git 'https://github.com/aladiha/nehool-project.git'
      }
   }
   stage('Dotnet Restore'){
        steps{
        sh "dotnet restore"
        }
    }
    
  stage('Build') {
   steps {
        
    sh "dotnet build"
   }
  }
  stage('Unit Tests') {
   steps {
    sh 'dotnet test'
   }
  }

  }
 }

