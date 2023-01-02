# az extension add --source https://workerappscliextension.blob.core.windows.net/azure-cli-extension/containerapp-0.2.0-py2.py3-none-any.whl --yes
param($containerAppName)
while ($true)
{
    $revisions = $(az containerapp revision list -n $containerAppName -g ContainerAppDeployment  --only-show-errors) | ConvertFrom-Json
    foreach ($revision in $revisions)
    {
        if($revision.trafficWeight -gt 0)
        {
            Write-Host "$(Get-Date) $($revision.name) $($revision.trafficWeight) $($revision.replicas)"
        }
    }
}