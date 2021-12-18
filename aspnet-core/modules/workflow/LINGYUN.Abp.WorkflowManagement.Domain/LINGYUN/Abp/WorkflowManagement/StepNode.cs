﻿using System;
using WorkflowCore.Models;

namespace LINGYUN.Abp.WorkflowManagement
{
    public class StepNode : Step
    {
        protected StepNode()
        {
        }

        public StepNode(
            Guid id, 
            Guid workflowId, 
            string name, 
            string stepType,
            string cancelCondition, 
            WorkflowErrorHandling? errorBehavior = null, 
            TimeSpan? retryInterval = null,
            bool saga = false, 
            Guid? parentId = null,
            Guid? tenantId = null) 
            : base(id, workflowId, name, stepType, cancelCondition, errorBehavior, retryInterval, saga, parentId, tenantId)
        {
        }
    }
}